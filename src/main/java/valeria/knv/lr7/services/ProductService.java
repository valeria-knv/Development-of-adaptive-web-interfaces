package valeria.knv.lr7.services;

import org.springframework.stereotype.Service;
import valeria.knv.lr7.models.Product;
import valeria.knv.lr7.services.interfaces.IProductService;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

//@Service
public class ProductService implements IProductService {
    private final List<Product> products = new ArrayList<>();

    public ProductService() {
        for (int i = 1; i <= 10; i++) {
            products.add(new Product(UUID.randomUUID().toString(), "Product-" + i, (double) (10000 * i)));
        }
    }

    @Override
    public List<Product> getAll() {
        return products;
    }

    @Override
    public Product getById(String id) {
        return products.stream().filter(product -> product.getId().equals(id)).findFirst().orElse(null);
    }

    @Override
    public Product create(Product entity) {
        entity.setId(UUID.randomUUID().toString());
        products.add(entity);
        return entity;
    }

    @Override
    public Product update(String id, Product entity) {
        Product existingProduct = getById(id);
        if (existingProduct != null) {
            existingProduct.setName(entity.getName());
            existingProduct.setPrice(entity.getPrice());
        }
        return existingProduct;
    }

    @Override
    public void delete(String id) {
        products.removeIf(product -> product.getId().equals(id));
    }
}
