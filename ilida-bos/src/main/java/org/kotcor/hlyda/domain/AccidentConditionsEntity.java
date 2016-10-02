package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentConditions", schema = "dbo", catalog = "IlidaDB")
public class AccidentConditionsEntity {
    private long id;
    private String description;
    private List<AccidentCarsEntity> cars;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentConditionsEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Description", nullable = false, length = 2147483647)
    public String getDescription() {
        return description;
    }

    public AccidentConditionsEntity setDescription(String description) {
        this.description = description;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentConditionsEntity that = (AccidentConditionsEntity) o;

        if (id != that.id) return false;
        if (description != null ? !description.equals(that.description) : that.description != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (description != null ? description.hashCode() : 0);
        return result;
    }

    @ManyToMany(mappedBy = "conditions")
    public List<AccidentCarsEntity> getCars() {
        return cars;
    }

    public AccidentConditionsEntity setCars(List<AccidentCarsEntity> cars) {
        this.cars = cars;
        return this;
    }
}
