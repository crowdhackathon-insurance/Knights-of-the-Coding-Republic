package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.Set;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Users", schema = "dbo", catalog = "IlidaDB")
public class UsersEntity {
    private long id;
    private String username;
    private String password;
    private String fullName;
    private String idCard;
    private Set<RolesEntity> roles;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public UsersEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Username", nullable = false, length = 50)
    public String getUsername() {
        return username;
    }

    public UsersEntity setUsername(String username) {
        this.username = username;
        return this;
    }

    @Basic
    @Column(name = "Password", nullable = false, length = 50)
    public String getPassword() {
        return password;
    }

    public UsersEntity setPassword(String password) {
        this.password = password;
        return this;
    }

    @Basic
    @Column(name = "FullName", nullable = false, length = 255)
    public String getFullName() {
        return fullName;
    }

    public UsersEntity setFullName(String fullName) {
        this.fullName = fullName;
        return this;
    }

    @Basic
    @Column(name = "IdCard", nullable = false, length = 10)
    public String getIdCard() {
        return idCard;
    }

    public UsersEntity setIdCard(String idCard) {
        this.idCard = idCard;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        UsersEntity that = (UsersEntity) o;

        if (id != that.id) return false;
        if (username != null ? !username.equals(that.username) : that.username != null) return false;
        if (password != null ? !password.equals(that.password) : that.password != null) return false;
        if (fullName != null ? !fullName.equals(that.fullName) : that.fullName != null) return false;
        if (idCard != null ? !idCard.equals(that.idCard) : that.idCard != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (username != null ? username.hashCode() : 0);
        result = 31 * result + (password != null ? password.hashCode() : 0);
        result = 31 * result + (fullName != null ? fullName.hashCode() : 0);
        result = 31 * result + (idCard != null ? idCard.hashCode() : 0);
        return result;
    }

    @ManyToMany
    @JoinTable(name = "UserRoles", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "UserId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "RoleId", referencedColumnName = "Id", nullable = false))
    public Set<RolesEntity> getRoles() {
        return roles;
    }

    public UsersEntity setRoles(Set<RolesEntity> roles) {
        this.roles = roles;
        return this;
    }
}
