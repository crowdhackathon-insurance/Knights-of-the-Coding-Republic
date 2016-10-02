package org.kotcor.hlyda.service;

import org.kotcor.hlyda.domain.AccidentsEntity;
import org.kotcor.hlyda.domain.enumerations.AccidentStatus;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.http.ResponseEntity;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import javax.inject.Inject;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Service
public class PollingService {

    String baseUrl;

    @Inject
    ApplicationEventPublisher publisher;

    @Inject
    @Qualifier("data-api")
    RestTemplate apiTemplate;

//    @Scheduled(fixedRate = 5000)
    public void pollForAccidents() {
        ResponseEntity<AccidentsEntity[]> response = apiTemplate.getForEntity(baseUrl, AccidentsEntity[].class, AccidentStatus.inProcess.getValue());
        AccidentsEntity[] accidents = response.getBody();
        publisher.publishEvent(accidents);
    }

}
