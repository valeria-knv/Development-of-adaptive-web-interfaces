package valeria.knv.lr5.utils.http;

import org.springframework.http.HttpStatus;
import java.util.HashMap;
import java.util.Map;

public class Utility {
    static public Map<String, Object> handlingLocalException(Exception e, HttpStatus status){
        Map<String, Object> res = new HashMap<>();
        res.put("statusCode", status.value());
        res.put("errorMessage", e.getMessage());
        res.put("source", "lr5-service");
        return res;
    }
}
