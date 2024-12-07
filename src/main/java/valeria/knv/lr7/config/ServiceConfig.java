package valeria.knv.lr7.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import org.springframework.context.annotation.Scope;
import valeria.knv.lr7.services.OrderService;
import valeria.knv.lr7.services.ProductService;
import valeria.knv.lr7.services.UserService;

@Configuration
public class ServiceConfig {

    @Bean
    //@Scope("singleton") // За замовчуванням, тому можна опустити
    //@Scope("prototype") // Створюється новий екземпляр щоразу
    //@Scope("request") // Один екземпляр на HTTP-запит
    public OrderService orderService() {
        return new OrderService();
    }

    @Bean
    public ProductService productService() {
        return new ProductService();
    }

    @Bean
    public UserService userService() {
        return new UserService();
    }
}