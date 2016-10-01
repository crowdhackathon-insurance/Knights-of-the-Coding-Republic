package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Companies", schema = "dbo", catalog = "IlidaDB")
public class CompaniesEntity {
    private long id;
    private String name;
    private List<AccidentsEntity> accidents;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public CompaniesEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Name", nullable = false, length = 255)
    public String getName() {
        return name;
    }

    public CompaniesEntity setName(String name) {
        this.name = name;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        CompaniesEntity that = (CompaniesEntity) o;

        if (id != that.id) return false;
        if (name != null ? !name.equals(that.name) : that.name != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (name != null ? name.hashCode() : 0);
        return result;
    }

    @ManyToMany(mappedBy = "companies")
    public List<AccidentsEntity> getAccidents() {
        return accidents;
    }

    public CompaniesEntity setAccidents(List<AccidentsEntity> accidents) {
        this.accidents = accidents;
        return this;
    }
}
