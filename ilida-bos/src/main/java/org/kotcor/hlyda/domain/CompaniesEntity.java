package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Companies", schema = "dbo", catalog = "IlidaDB")
public class CompaniesEntity {
    private long Id;
    private String Name;
    private List<AccidentsEntity> Accidents;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public CompaniesEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Name", nullable = false, length = 255)
    public String getName() {
        return Name;
    }

    public CompaniesEntity setName(String name) {
        this.Name = name;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        CompaniesEntity that = (CompaniesEntity) o;

        if (Id != that.Id) return false;
        if (Name != null ? !Name.equals(that.Name) : that.Name != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (Name != null ? Name.hashCode() : 0);
        return result;
    }

    @ManyToMany(mappedBy = "accidentCompanies")
    public List<AccidentsEntity> getAccidents() {
        return Accidents;
    }

    public CompaniesEntity setAccidents(List<AccidentsEntity> accidents) {
        this.Accidents = accidents;
        return this;
    }
}
