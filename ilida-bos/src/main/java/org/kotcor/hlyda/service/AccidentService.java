package org.kotcor.hlyda.service;

import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.MapperFeature;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.kotcor.hlyda.domain.AccidentsEntity;
import org.kotcor.hlyda.domain.enumerations.AccidentStatus;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import javax.annotation.PostConstruct;
import javax.inject.Inject;
import java.io.IOException;
import java.util.Arrays;
import java.util.Collection;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Service
public class AccidentService {

    @Inject
    @Qualifier("data-api")
    RestTemplate apiTemplate;

    String baseUrl = "http://ilida-api.azurewebsites.net/";

    ObjectMapper mapper;

    @PostConstruct
    public void init() {
        mapper = new ObjectMapper();
        mapper.configure(MapperFeature.ACCEPT_CASE_INSENSITIVE_PROPERTIES, true);
        mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
    }

    public AccidentsEntity getAccidentById(int id) {
        return apiTemplate.getForObject(baseUrl, AccidentsEntity.class, id);
    }

    public Collection<AccidentsEntity> getAllAccidents() throws IOException {
        String jsonString = apiTemplate.getForEntity(baseUrl + "api/accidents", String.class).getBody();
        AccidentsEntity[] accidents = mapper.readValue(jsonString, AccidentsEntity[].class);
        return Arrays.asList(accidents);
    }

    public AccidentsEntity[] getAllAccidentsWithStatus(AccidentStatus status) throws IOException {
        String jsonString = apiTemplate.getForEntity(baseUrl + "api/accidents", String.class).getBody();
        AccidentsEntity[] accidents = mapper.readValue(jsonString, AccidentsEntity[].class);
        for (AccidentsEntity accident : accidents) {
            accident.setWorkflowStatusId(accident.getWorkflowStatus().getId());
        }
        return Arrays.stream(accidents).filter(accidentsEntity -> accidentsEntity.getWorkflowStatusId() == status.getValue()).toArray(AccidentsEntity[]::new);
    }

    public void updateAccident(AccidentsEntity accident) {
        apiTemplate.put(baseUrl, accident);
    }

    public void approveIncident(AccidentsEntity accident) {
        apiTemplate.postForObject(baseUrl + "api/accidents/" + accident.getId() + "/process?userId=3", "", String.class);
    }
}
