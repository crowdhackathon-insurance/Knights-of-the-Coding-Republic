package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentConditions", schema = "dbo", catalog = "IlidaDB")
public class AccidentConditionsEntity {
    private long Id;
    private String Description;
    private List<AccidentCarsEntity> AccidentCars;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentConditionsEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Description", nullable = false, length = 2147483647)
    public String getDescription() {
        return Description;
    }

    public AccidentConditionsEntity setDescription(String description) {
        this.Description = description;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentConditionsEntity that = (AccidentConditionsEntity) o;

        if (Id != that.Id) return false;
        if (Description != null ? !Description.equals(that.Description) : that.Description != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (Description != null ? Description.hashCode() : 0);
        return result;
    }

    @ManyToMany(mappedBy = "accidentConditions")
    public List<AccidentCarsEntity> getAccidentCars() {
        return AccidentCars;
    }

    public AccidentConditionsEntity setAccidentCars(List<AccidentCarsEntity> accidentCars) {
        this.AccidentCars = accidentCars;
        return this;
    }
}
