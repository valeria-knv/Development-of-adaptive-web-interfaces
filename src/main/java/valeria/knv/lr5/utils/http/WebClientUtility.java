package valeria.knv.lr5.utils.http;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.reactive.function.client.WebClient;

import java.util.Map;
import java.util.concurrent.atomic.AtomicInteger;

import static org.springframework.http.MediaType.APPLICATION_JSON;

public class WebClientUtility {
    private static final Logger LOGGER = LoggerFactory.getLogger(WebClientUtility.class);

    static public ResponseEntity<?> postRequest(String body, Map<String, String> headers, String URL) {
        AtomicInteger statusCode = new AtomicInteger();
        WebClient client = WebClient.builder()
                .build();

        String response = client.post()
                .uri(URL)
                .contentType(APPLICATION_JSON)
                .bodyValue(body)
                .exchangeToMono(clientResponse -> {
                    statusCode.set(clientResponse.statusCode().value());
                    return clientResponse.bodyToMono(String.class);
                })
                .doOnError(error -> {
                    LOGGER.error("An error has occurred {}: {}", error.getClass().getSimpleName(), error.getMessage());
                })
                .block();

        return new ResponseEntity<>(response, HttpStatus.valueOf(statusCode.get()));
    }

    static public ResponseEntity<?> getRequest(String URL) {
        AtomicInteger statusCode = new AtomicInteger();
        WebClient client = WebClient.builder()
                .build();

        String response = client.get()
                .uri(URL)
                .exchangeToMono(clientResponse -> {
                    statusCode.set(clientResponse.statusCode().value());
                    return clientResponse.bodyToMono(String.class);
                })
                .doOnError(error -> {
                    LOGGER.error("An error has occurred {}: {}", error.getClass().getSimpleName(), error.getMessage());
                })
                .block();

        return new ResponseEntity<>(response, HttpStatus.valueOf(statusCode.get()));
    }
}
