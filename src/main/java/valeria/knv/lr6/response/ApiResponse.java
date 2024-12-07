package valeria.knv.lr6.response;

import com.fasterxml.jackson.annotation.JsonInclude;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

@Getter
@Setter
@JsonInclude(JsonInclude.Include.NON_EMPTY)
@Schema(description = "Стандартна структура відповіді API")
public class ApiResponse<T> {

    @Schema(description = "Повідомлення про статус виконання операції", example = "Запит успішно виконано")
    private String message;

    @Schema(description = "HTTP-статус відповіді", example = "200")
    private int statusCode;

    @Schema(description = "Дані у відповіді", nullable = true)
    private T data;

    public ApiResponse(String message, HttpStatus statusCode, T data) {
        this.message = message;
        this.statusCode = statusCode.value();
        this.data = data;
    }

    public ApiResponse(String message, HttpStatus statusCode) {
        this.message = message;
        this.statusCode = statusCode.value();
    }

    public ResponseEntity<?> toResponseEntity() {
        return new ResponseEntity<>(this, HttpStatus.valueOf(statusCode));
    }
}
