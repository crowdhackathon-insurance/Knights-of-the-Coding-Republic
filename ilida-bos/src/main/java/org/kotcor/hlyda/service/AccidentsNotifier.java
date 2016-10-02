package org.kotcor.hlyda.service;

import org.kotcor.hlyda.domain.AccidentsEntity;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.event.EventListener;
import org.springframework.messaging.simp.SimpMessageSendingOperations;
import org.springframework.stereotype.Component;

import javax.inject.Inject;
import java.util.Collection;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Component
public class AccidentsNotifier {

    private final Logger log = LoggerFactory.getLogger(AccidentsNotifier.class);

    @Inject
    SimpMessageSendingOperations messagingTemplate;

    @EventListener
    public void notifyAlert(AccidentsEntity[] accidents) {
        messagingTemplate.convertAndSend("/topic/accidents", accidents);
    }

}
