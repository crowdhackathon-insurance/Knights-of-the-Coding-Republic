package org.kotcor.hlyda.web.rest;

import org.kotcor.hlyda.domain.AccidentsEntity;
import org.kotcor.hlyda.domain.enumerations.AccidentStatus;
import org.kotcor.hlyda.service.AccidentService;
import org.kotcor.hlyda.web.rest.util.HeaderUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.inject.Inject;
import java.io.IOException;
import java.util.Collection;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@RestController
@RequestMapping("/api")
public class AccidentResource {

    private final Logger log = LoggerFactory.getLogger(AccidentResource.class);

    @Inject
    ApplicationEventPublisher publisher;

    @Inject
    AccidentService accidentService;

    @RequestMapping(value = "/accident",
        method = RequestMethod.GET,
        produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Collection<AccidentsEntity>> getAllAccidents() throws IOException {
        log.info("Fetching all accidents");
        Collection<AccidentsEntity> accidents = accidentService.getAllAccidents();
        return ResponseEntity
            .ok()
            .body(accidents);
    }

    @RequestMapping(value = "/accident/status/{statusId}",
        method = RequestMethod.GET,
        produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<AccidentsEntity[]> getAllAccidentsWithStatus(@PathVariable Integer statusId) throws IOException {
        log.info("Fetching all accidents");
        AccidentsEntity[] accidents = accidentService.getAllAccidentsWithStatus(AccidentStatus.get(statusId));
        return ResponseEntity
            .ok()
            .body(accidents);
    }

    @RequestMapping(value = "/accident",
        method = RequestMethod.PUT,
        produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Void> updateAccident(@RequestBody AccidentsEntity accident) {
        log.info("Updating accident: {}", accident.getId());
        accidentService.updateAccident(accident);
        return ResponseEntity.ok()
            .headers(HeaderUtil.createAlert("Successfully updated accident " + accident.getId(), accident.getId() + ""))
            .build();
    }

    @RequestMapping(value = "/accident/approve/{accidentId}",
        method = RequestMethod.POST,
        produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Void> approveIncident(@PathVariable int accidentId) {
        accidentService.approveIncident(new AccidentsEntity().setId(accidentId));
        return ResponseEntity.ok()
            .headers(HeaderUtil.createAlert("Successfully updated accident " + accidentId, accidentId + ""))
            .build();
    }

}
