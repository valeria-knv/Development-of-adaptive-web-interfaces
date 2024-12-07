package valeria.knv.lr7.models;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class Order {
    private String id;
    private String productName;
    private int quantity;
}
