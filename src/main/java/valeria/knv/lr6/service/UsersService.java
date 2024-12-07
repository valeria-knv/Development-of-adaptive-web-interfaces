package valeria.knv.lr6.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import valeria.knv.lr6.entity.User;
import valeria.knv.lr6.repository.UsersRepository;
import valeria.knv.lr6.response.ApiResponse;

import java.util.List;
import java.util.Optional;

@Service
public class UsersService {
    @Autowired private UsersRepository usersRepository;

    public ApiResponse<List<User>> getUsers(){
        List<User> users = usersRepository.getAll();
        if (users.size() > 0)
            return new ApiResponse<>("Users found", HttpStatus.OK, users);
        else
            return new ApiResponse<>("User list empty", HttpStatus.OK);
    }

    public ApiResponse<User> getUserById(String id) {
        Optional<User> user = usersRepository.getById(id);
        if (user.isPresent())
            return new ApiResponse<>("User found", HttpStatus.OK, user.get());
        else
            return new ApiResponse<>("User not found", HttpStatus.BAD_REQUEST);
    }

    public ApiResponse<User> create(User user){
        return new ApiResponse<>("User created", HttpStatus.OK, usersRepository.create(user));
    }
}
