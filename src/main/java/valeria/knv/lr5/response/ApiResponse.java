package valeria.knv.lr5.response;

import com.fasterxml.jackson.annotation.JsonInclude;
import lombok.Getter;
import lombok.Setter;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

// Завдання 2
@Getter
@Setter
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class ApiResponse<T> {
    private String message;
    private int statusCode;
    private T data;

    public ApiResponse(String message, HttpStatus statusCode, T data){
        this.message = message;
        this.statusCode = statusCode.value();
        this.data = data;
    }

    public ApiResponse(String message, HttpStatus statusCode){
        this.message = message;
        this.statusCode = statusCode.value();
    }

    public ResponseEntity<?> toResponseEntity(){
        return new ResponseEntity<>(this, HttpStatus.valueOf(statusCode));
    }
}
