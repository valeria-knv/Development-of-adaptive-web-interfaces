package valeria.knv.lr7.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import valeria.knv.lr7.models.Product;
import valeria.knv.lr7.response.ApiResponse;
import valeria.knv.lr7.services.ProductService;

import java.util.List;


@RestController
@RequestMapping("/products")
public class ProductController {
    @Autowired
    private ProductService productService;

    @GetMapping
    public ResponseEntity<?> getAll() {
        List<Product> products = productService.getAll();
        return new ApiResponse<>("Продукти знайдені", HttpStatus.OK, products).toResponseEntity();
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getById(@PathVariable String id) {
        Product product = productService.getById(id);
        return new ApiResponse<>(product == null ? "Продукт не знайдено" : "Продукт знайдено", product == null ? HttpStatus.BAD_REQUEST : HttpStatus.OK, product).toResponseEntity();
    }

    @PostMapping
    public ResponseEntity<?> create(@RequestBody Product product) {
        Product createdProduct = productService.create(product);
        return new ApiResponse<>("Продукт створено", HttpStatus.OK, createdProduct).toResponseEntity();
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> update(@PathVariable String id, @RequestBody Product product) {
        Product updatedProduct = productService.update(id, product);
        return new ApiResponse<>("Продукт оновлено", HttpStatus.OK, updatedProduct).toResponseEntity();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> delete(@PathVariable String id) {
        productService.delete(id);
        return new ApiResponse<>("Продукт видалено", HttpStatus.OK).toResponseEntity();
    }
}
