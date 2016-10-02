package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.Set;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Roles", schema = "dbo", catalog = "IlidaDB")
public class RolesEntity {
    private long id;
    private String name;
    private Set<UsersEntity> users;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public RolesEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Name", nullable = false, length = 50)
    public String getName() {
        return name;
    }

    public RolesEntity setName(String name) {
        this.name = name;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        RolesEntity that = (RolesEntity) o;

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

    @ManyToMany(mappedBy = "roles")
    public Set<UsersEntity> getUsers() {
        return users;
    }

    public RolesEntity setUsers(Set<UsersEntity> users) {
        this.users = users;
        return this;
    }
}
