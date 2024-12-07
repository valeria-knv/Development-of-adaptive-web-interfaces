package valeria.knv.lr7.services;

import org.springframework.stereotype.Service;
import valeria.knv.lr7.models.Order;
import valeria.knv.lr7.services.interfaces.IOrderService;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

//@Service
public class OrderService implements IOrderService {
    private final List<Order> orders = new ArrayList<>();

    public OrderService() {
        for (int i = 1; i <= 10; i++) {
            orders.add(
                new Order(
                        UUID.randomUUID().toString(),
                        "Order-" + i,
                        1000*i
                )
            );
        }
    }

    @Override
    public List<Order> getAll() {
        return orders;
    }

    @Override
    public Order getById(String id) {
        return orders.stream().filter(order -> order.getId().equals(id)).findFirst().orElse(null);
    }

    @Override
    public Order create(Order entity) {
        entity.setId(UUID.randomUUID().toString());
        orders.add(entity);
        return entity;
    }

    @Override
    public Order update(String id, Order entity) {
        Order existingOrder = getById(id);
        if (existingOrder != null) {
            existingOrder.setProductName(entity.getProductName());
            existingOrder.setQuantity(entity.getQuantity());
        }
        return existingOrder;
    }

    @Override
    public void delete(String id) {
        orders.removeIf(order -> order.getId().equals(id));
    }
}
