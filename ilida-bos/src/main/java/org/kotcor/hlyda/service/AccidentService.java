package org.kotcor.hlyda.service;

import org.kotcor.hlyda.domain.AccidentsEntity;
import org.kotcor.hlyda.domain.enumerations.AccidentStatus;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import javax.inject.Inject;
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

    String baseUrl = "";

    public AccidentsEntity getAccidentById(int id) {
        return apiTemplate.getForObject(baseUrl, AccidentsEntity.class, id);
    }

    public Collection<AccidentsEntity> getAllAccidents() {
        ResponseEntity<AccidentsEntity[]> response = apiTemplate.getForEntity(baseUrl, AccidentsEntity[].class);
        AccidentsEntity[] accidents = response.getBody();
        return Arrays.asList(accidents);
    }

    public Collection<AccidentsEntity> getAllAccidentsWithStatus(AccidentStatus status) {
        ResponseEntity<AccidentsEntity[]> response = apiTemplate.getForEntity(baseUrl, AccidentsEntity[].class, status.getValue());
        AccidentsEntity[] accidents = response.getBody();
        return Arrays.asList(accidents);
    }

    public void updateAccident(AccidentsEntity accident) {
        apiTemplate.put(baseUrl, accident);
    }

}
