package org.kotcor.hlyda.config;

import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.MapperFeature;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.datatype.jsr310.ser.ZonedDateTimeSerializer;
import org.springframework.boot.autoconfigure.jackson.Jackson2ObjectMapperBuilderCustomizer;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.time.ZoneId;
import java.time.format.DateTimeFormatter;

@Configuration
public class JacksonConfiguration {

    public static final DateTimeFormatter ISO_FIXED_FORMAT =
        DateTimeFormatter.ofPattern("yyyy-MM-dd'T'HH:mm:ss.SSS'Z'").withZone(ZoneId.of("Z"));

    @Bean
    public Jackson2ObjectMapperBuilderCustomizer jacksonCustomizer() {
        return jackson2ObjectMapperBuilder -> jackson2ObjectMapperBuilder
            .serializers(new ZonedDateTimeSerializer(ISO_FIXED_FORMAT))
            .featuresToDisable(SerializationFeature.FAIL_ON_EMPTY_BEANS)
            .featuresToEnable(MapperFeature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
            .featuresToDisable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
    }

}
