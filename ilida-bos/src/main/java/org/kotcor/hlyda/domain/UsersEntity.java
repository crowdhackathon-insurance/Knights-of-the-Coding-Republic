package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.Set;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Users", schema = "dbo", catalog = "IlidaDB")
public class UsersEntity {
    private long Id;
    private String Username;
    private String Password;
    private String FullName;
    private String IdCard;
    private Set<RolesEntity> Roles;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public UsersEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Username", nullable = false, length = 50)
    public String getUsername() {
        return Username;
    }

    public UsersEntity setUsername(String username) {
        this.Username = username;
        return this;
    }

    @Basic
    @Column(name = "Password", nullable = false, length = 50)
    public String getPassword() {
        return Password;
    }

    public UsersEntity setPassword(String password) {
        this.Password = password;
        return this;
    }

    @Basic
    @Column(name = "FullName", nullable = false, length = 255)
    public String getFullName() {
        return FullName;
    }

    public UsersEntity setFullName(String fullName) {
        this.FullName = fullName;
        return this;
    }

    @Basic
    @Column(name = "IdCard", nullable = false, length = 10)
    public String getIdCard() {
        return IdCard;
    }

    public UsersEntity setIdCard(String idCard) {
        this.IdCard = idCard;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        UsersEntity that = (UsersEntity) o;

        if (Id != that.Id) return false;
        if (Username != null ? !Username.equals(that.Username) : that.Username != null) return false;
        if (Password != null ? !Password.equals(that.Password) : that.Password != null) return false;
        if (FullName != null ? !FullName.equals(that.FullName) : that.FullName != null) return false;
        if (IdCard != null ? !IdCard.equals(that.IdCard) : that.IdCard != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (Username != null ? Username.hashCode() : 0);
        result = 31 * result + (Password != null ? Password.hashCode() : 0);
        result = 31 * result + (FullName != null ? FullName.hashCode() : 0);
        result = 31 * result + (IdCard != null ? IdCard.hashCode() : 0);
        return result;
    }

    @ManyToMany
    @JoinTable(name = "UserRoles", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "UserId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "RoleId", referencedColumnName = "Id", nullable = false))
    public Set<RolesEntity> getRoles() {
        return Roles;
    }

    public UsersEntity setRoles(Set<RolesEntity> roles) {
        this.Roles = roles;
        return this;
    }
}
