package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentWitnesses", schema = "dbo", catalog = "IlidaDB")
public class AccidentWitnessesEntity {
    private long id;
    private String idCard;
    private long accidentId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentWitnessesEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "IdCard", nullable = false, length = 10)
    public String getIdCard() {
        return idCard;
    }

    public AccidentWitnessesEntity setIdCard(String idCard) {
        this.idCard = idCard;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return accidentId;
    }

    public AccidentWitnessesEntity setAccidentId(long accidentId) {
        this.accidentId = accidentId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentWitnessesEntity that = (AccidentWitnessesEntity) o;

        if (id != that.id) return false;
        if (accidentId != that.accidentId) return false;
        if (idCard != null ? !idCard.equals(that.idCard) : that.idCard != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (idCard != null ? idCard.hashCode() : 0);
        result = 31 * result + (int) (accidentId ^ (accidentId >>> 32));
        return result;
    }
}
