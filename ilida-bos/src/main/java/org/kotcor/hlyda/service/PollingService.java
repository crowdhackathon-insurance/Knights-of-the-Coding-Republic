package org.kotcor.hlyda.service;

import org.kotcor.hlyda.domain.AccidentsEntity;
import org.kotcor.hlyda.domain.enumerations.AccidentStatus;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;

import javax.inject.Inject;
import java.io.IOException;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Service
public class PollingService {

    String baseUrl = "http://ilida-api.azurewebsites.net/";

    @Inject
    ApplicationEventPublisher publisher;

    @Inject
    AccidentService accidentService;

    @Scheduled(fixedRate = 3000)
    public void pollForAccidents() throws IOException {
        AccidentsEntity[] accidents = accidentService.getAllAccidentsWithStatus(AccidentStatus.get(AccidentStatus.inProcess.getValue()));
        publisher.publishEvent(accidents);
    }

}
