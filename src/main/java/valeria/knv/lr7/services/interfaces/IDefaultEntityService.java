package valeria.knv.lr7.services.interfaces;

import java.util.List;

public interface IDefaultEntityService<T> {
    List<T> getAll();
    T getById(String id);
    T create(T entity);
    T update(String id, T entity);
    void delete(String id);
}
