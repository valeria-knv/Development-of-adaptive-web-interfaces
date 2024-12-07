package valeria.knv.lr6.controller;

import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.responses.ApiResponses;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import valeria.knv.lr6.entity.User;
import valeria.knv.lr6.service.UsersService;

@RestController
@RequestMapping("users")
public class UsersController {
    @Autowired
    private UsersService usersService;

    @Operation(summary = "Отримати список всіх користувачів", description = "Повертає список всіх зареєстрованих користувачів")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "200", content = @Content(schema = @Schema(implementation = ApiResponse.class)), description = "Список користувачів успішно отримано"),
            @ApiResponse(responseCode = "500", content = @Content(schema = @Schema(implementation = ApiResponse.class)), description = "Внутрішня помилка сервера")
    })
    @GetMapping()
    public ResponseEntity<?> getAll() {
        return usersService.getUsers().toResponseEntity();
    }

    @Operation(summary = "Отримати користувача за ID", description = "Повертає дані користувача за вказаним унікальним ідентифікатором")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "200", content = @Content(schema = @Schema(implementation = ApiResponse.class)), description = "Користувача успішно знайдено"),
            @ApiResponse(responseCode = "400", content = @Content(schema = @Schema(implementation = ApiResponse.class)), description = "Користувача не знайдено")
    })
    @GetMapping("/{id}")
    public ResponseEntity<?> getById(
            @PathVariable
            @Schema(description = "Унікальний ідентифікатор користувача", example = "12345") String id
    ) {
        return usersService.getUserById(id).toResponseEntity();
    }

    @Operation(summary = "Створити нового користувача", description = "Додає нового користувача в базу даних")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "200", content = @Content(schema = @Schema(implementation = ApiResponse.class)), description = "Користувача успішно створено"),
            @ApiResponse(responseCode = "400", content = @Content(schema = @Schema(implementation = ApiResponse.class)), description = "Некоректні дані для створення користувача")
    })
    @PostMapping()
    public ResponseEntity<?> create(
            @RequestBody @io.swagger.v3.oas.annotations.parameters.RequestBody(description = "Дані нового користувача", required = true,
                    content = @Content(schema = @Schema(implementation = User.class))) User user
    ) {
        return usersService.create(user).toResponseEntity();
    }
}
