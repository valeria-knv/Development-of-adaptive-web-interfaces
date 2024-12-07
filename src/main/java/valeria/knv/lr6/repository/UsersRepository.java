package valeria.knv.lr6.repository;

import org.springframework.stereotype.Component;
import valeria.knv.lr6.entity.User;

import java.util.*;

@Component
public class UsersRepository {
    private final List<User> users = new ArrayList<>();

    public List<User> getAll() {
        return users;
    }

    public Optional<User> getById(String id) {
        return users.stream().filter(u -> Objects.equals(u.getId(), id)).findFirst();
    }

    public User create(User user){
        user.setId(UUID.randomUUID().toString());
        users.add(user);
        return user;
    }
}
