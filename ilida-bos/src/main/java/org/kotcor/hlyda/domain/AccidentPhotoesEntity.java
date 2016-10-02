package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentPhotoes", schema = "dbo", catalog = "IlidaDB")
public class AccidentPhotoesEntity {
    private long Id;
    private String Url;
    private long AccidentId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentPhotoesEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Url", nullable = false, length = 2147483647)
    public String getUrl() {
        return Url;
    }

    public AccidentPhotoesEntity setUrl(String url) {
        this.Url = url;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return AccidentId;
    }

    public AccidentPhotoesEntity setAccidentId(long accidentId) {
        this.AccidentId = accidentId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentPhotoesEntity that = (AccidentPhotoesEntity) o;

        if (Id != that.Id) return false;
        if (AccidentId != that.AccidentId) return false;
        if (Url != null ? !Url.equals(that.Url) : that.Url != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (Url != null ? Url.hashCode() : 0);
        result = 31 * result + (int) (AccidentId ^ (AccidentId >>> 32));
        return result;
    }
}
