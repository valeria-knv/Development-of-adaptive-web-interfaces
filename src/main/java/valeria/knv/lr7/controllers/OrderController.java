package valeria.knv.lr7.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import valeria.knv.lr7.models.Order;
import valeria.knv.lr7.response.ApiResponse;
import valeria.knv.lr7.services.OrderService;

import java.util.List;


@RestController
@RequestMapping("/orders")
public class OrderController {
    @Autowired
    private OrderService orderService;

    @GetMapping
    public ResponseEntity<?> getAll() {
        List<Order> orders = orderService.getAll();
        return new ApiResponse<>("Замовлення знайдені", HttpStatus.OK, orders).toResponseEntity();
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getById(@PathVariable String id) {
        Order order = orderService.getById(id);
        return new ApiResponse<>(order == null ? "Замовлення не знайдено" : "Замовлення знайдено", order == null ? HttpStatus.BAD_REQUEST : HttpStatus.OK, order).toResponseEntity();
    }

    @PostMapping
    public ResponseEntity<?> create(@RequestBody Order order) {
        Order createdOrder = orderService.create(order);
        return new ApiResponse<>("Замовлення створено", HttpStatus.OK, createdOrder).toResponseEntity();
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> update(@PathVariable String id, @RequestBody Order order) {
        Order updatedOrder = orderService.update(id, order);
        return new ApiResponse<>("Замовлення оновлено", HttpStatus.OK, updatedOrder).toResponseEntity();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> delete(@PathVariable String id) {
        orderService.delete(id);
        return new ApiResponse<>("Замовлення видалено", HttpStatus.OK).toResponseEntity();
    }
}
