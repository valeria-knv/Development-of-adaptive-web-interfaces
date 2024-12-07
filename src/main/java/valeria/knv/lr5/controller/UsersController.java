package valeria.knv.lr5.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import valeria.knv.lr5.entity.User;
import valeria.knv.lr5.service.UsersService;

import static org.springframework.http.MediaType.APPLICATION_JSON_VALUE;

@RestController
@RequestMapping("users")
public class UsersController {
    @Autowired private UsersService usersService;

    // Завдання 1
    @GetMapping(value = "mock", produces = APPLICATION_JSON_VALUE)
    public ResponseEntity<?> mock() {
        return usersService.mock();
    }

    // Завдання 3
    @GetMapping("")
    public ResponseEntity<?> getAll() {
        return usersService.getUsers().toResponseEntity();
    }

    // Завдання 3
    @GetMapping("/{id}")
    public ResponseEntity<?> getById(
            @PathVariable String id
    ) {
        return usersService.getUserById(id).toResponseEntity();
    }

    // Завдання 3
    @PostMapping()
    public ResponseEntity<?> create(
            @RequestBody User user
    ) {
        return usersService.create(user).toResponseEntity();
    }

    // Завдання 4
    @GetMapping("exception")
    public  ResponseEntity<?> exception() {
        throw new RuntimeException("Error");
    }
}
