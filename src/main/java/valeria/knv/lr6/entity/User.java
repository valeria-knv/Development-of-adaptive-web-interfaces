package valeria.knv.lr6.entity;

import io.swagger.v3.oas.annotations.media.Schema;
import lombok.*;

//@Data
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Schema(description = "Модель користувача") // Опис моделі
public class User {

    @Schema(description = "Унікальний ідентифікатор користувача", example = "123")
    private String id;

    @Schema(description = "Ім'я користувача", example = "John")
    private String firstName;

    @Schema(description = "Прізвище користувача", example = "Doe")
    private String lastName;

    @Schema(description = "Вік користувача", example = "25")
    private int age;
}
