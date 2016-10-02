package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.Set;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Roles", schema = "dbo", catalog = "IlidaDB")
public class RolesEntity {
    private long Id;
    private String Name;
    private Set<UsersEntity> Users;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public RolesEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Name", nullable = false, length = 50)
    public String getName() {
        return Name;
    }

    public RolesEntity setName(String name) {
        this.Name = name;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        RolesEntity that = (RolesEntity) o;

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

    @ManyToMany(mappedBy = "roles")
    public Set<UsersEntity> getUsers() {
        return Users;
    }

    public RolesEntity setUsers(Set<UsersEntity> users) {
        this.Users = users;
        return this;
    }
}
