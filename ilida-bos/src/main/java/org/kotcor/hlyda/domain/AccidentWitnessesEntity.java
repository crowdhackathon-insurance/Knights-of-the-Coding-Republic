package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentWitnesses", schema = "dbo", catalog = "IlidaDB")
public class AccidentWitnessesEntity {
    private long Id;
    private String IdCard;
    private long AccidentId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentWitnessesEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "IdCard", nullable = false, length = 10)
    public String getIdCard() {
        return IdCard;
    }

    public AccidentWitnessesEntity setIdCard(String idCard) {
        this.IdCard = idCard;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return AccidentId;
    }

    public AccidentWitnessesEntity setAccidentId(long accidentId) {
        this.AccidentId = accidentId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentWitnessesEntity that = (AccidentWitnessesEntity) o;

        if (Id != that.Id) return false;
        if (AccidentId != that.AccidentId) return false;
        if (IdCard != null ? !IdCard.equals(that.IdCard) : that.IdCard != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (IdCard != null ? IdCard.hashCode() : 0);
        result = 31 * result + (int) (AccidentId ^ (AccidentId >>> 32));
        return result;
    }
}
