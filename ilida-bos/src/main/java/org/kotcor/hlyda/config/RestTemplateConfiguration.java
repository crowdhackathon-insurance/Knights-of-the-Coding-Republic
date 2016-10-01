package org.kotcor.hlyda.config;

import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.client.SimpleClientHttpRequestFactory;
import org.springframework.web.client.RestTemplate;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Configuration
public class RestTemplateConfiguration {

    @Bean
    @Qualifier("data-api")
    public RestTemplate getLexiconRestTemplate() {

        RestTemplate restTemplate = new RestTemplate();
        SimpleClientHttpRequestFactory rf = (SimpleClientHttpRequestFactory) restTemplate.getRequestFactory();
        rf.setReadTimeout(20 * 1000);
        rf.setConnectTimeout(20 * 1000);
        return restTemplate;
    }
}
