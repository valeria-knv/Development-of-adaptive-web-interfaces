package valeria.knv.lr7.services;

import org.springframework.stereotype.Service;
import valeria.knv.lr7.models.User;
import valeria.knv.lr7.services.interfaces.IUserService;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

//@Service
public class UserService implements IUserService {
    private final List<User> users = new ArrayList<>();

    public UserService() {
        for (int i = 1; i <= 10; i++) {
            users.add(new User(UUID.randomUUID().toString(), "User" + i, "user" + i + "@example.com"));
        }
    }

    @Override
    public List<User> getAll() {
        return users;
    }

    @Override
    public User getById(String id) {
        return users.stream().filter(user -> user.getId().equals(id)).findFirst().orElse(null);
    }

    @Override
    public User create(User entity) {
        entity.setId(UUID.randomUUID().toString());
        users.add(entity);
        return entity;
    }

    @Override
    public User update(String id, User entity) {
        User existingUser = getById(id);
        if (existingUser != null) {
            existingUser.setName(entity.getName());
            existingUser.setEmail(entity.getEmail());
        }
        return existingUser;
    }

    @Override
    public void delete(String id) {
        users.removeIf(user -> user.getId().equals(id));
    }
}
