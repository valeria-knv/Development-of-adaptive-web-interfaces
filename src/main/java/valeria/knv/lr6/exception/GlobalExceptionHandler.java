package valeria.knv.lr6.exception;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import valeria.knv.lr6.response.ApiResponse;

import static org.springframework.http.HttpStatus.INTERNAL_SERVER_ERROR;

@ControllerAdvice
public class GlobalExceptionHandler {
    private static final Logger LOGGER = LoggerFactory.getLogger(GlobalExceptionHandler.class);

    @ExceptionHandler(Exception.class)
    public ResponseEntity<?> handleException(Exception e) {
        LOGGER.error(e.getMessage(), e);

        return new ApiResponse<>(e.getMessage(), INTERNAL_SERVER_ERROR).toResponseEntity();
    }

}
