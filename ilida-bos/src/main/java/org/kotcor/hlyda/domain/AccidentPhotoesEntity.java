package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentPhotoes", schema = "dbo", catalog = "IlidaDB")
public class AccidentPhotoesEntity {
    private long id;
    private String url;
    private long accidentId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentPhotoesEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Url", nullable = false, length = 2147483647)
    public String getUrl() {
        return url;
    }

    public AccidentPhotoesEntity setUrl(String url) {
        this.url = url;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return accidentId;
    }

    public AccidentPhotoesEntity setAccidentId(long accidentId) {
        this.accidentId = accidentId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentPhotoesEntity that = (AccidentPhotoesEntity) o;

        if (id != that.id) return false;
        if (accidentId != that.accidentId) return false;
        if (url != null ? !url.equals(that.url) : that.url != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (url != null ? url.hashCode() : 0);
        result = 31 * result + (int) (accidentId ^ (accidentId >>> 32));
        return result;
    }
}
