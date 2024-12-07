package valeria.knv.lr7.controllers;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import valeria.knv.lr7.models.User;
import valeria.knv.lr7.response.ApiResponse;
import valeria.knv.lr7.services.UserService;

import java.util.List;

@RestController
@RequestMapping("/users")
public class UserController {
    @Autowired private UserService userService;

    @GetMapping
    public ResponseEntity<?> getAll() {
        List<User> users = userService.getAll();
        return new ApiResponse<>("Користувачі знайдені", HttpStatus.OK, users).toResponseEntity();
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getById(@PathVariable String id) {
        User user = userService.getById(id);
        return new ApiResponse<>(user == null ? "Користувача не знайдено" : "Користувача знайдено", user == null ? HttpStatus.BAD_REQUEST : HttpStatus.OK, user).toResponseEntity();
    }

    @PostMapping
    public ResponseEntity<?> create(@RequestBody User user) {
        User createdUser = userService.create(user);
        return new ApiResponse<>("Користувача створено", HttpStatus.OK, createdUser).toResponseEntity();
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> update(@PathVariable String id, @RequestBody User user) {
        User updatedUser =  userService.update(id, user);
        return new ApiResponse<>("Користувача оновлено", HttpStatus.OK, updatedUser).toResponseEntity();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> delete(@PathVariable String id) {
        userService.delete(id);
        return new ApiResponse<>("Користувача видалено", HttpStatus.OK).toResponseEntity();
    }
}
