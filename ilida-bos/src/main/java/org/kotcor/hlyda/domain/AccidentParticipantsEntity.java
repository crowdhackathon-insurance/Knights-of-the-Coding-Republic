package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentParticipants", schema = "dbo", catalog = "IlidaDB")
public class AccidentParticipantsEntity {
    private long Id;
    private String IdCard;
    private boolean IsDriver;
    private boolean HasInjuries;
    private String SignUrl;
    private long AccidentId;
    private Long AccidentCarId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentParticipantsEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "IdCard", nullable = false, length = 10)
    public String getIdCard() {
        return IdCard;
    }

    public AccidentParticipantsEntity setIdCard(String idCard) {
        this.IdCard = idCard;
        return this;
    }

    @Basic
    @Column(name = "IsDriver", nullable = false)
    public boolean isDriver() {
        return IsDriver;
    }

    public AccidentParticipantsEntity setDriver(boolean driver) {
        IsDriver = driver;
        return this;
    }

    @Basic
    @Column(name = "HasInjuries", nullable = false)
    public boolean isHasInjuries() {
        return HasInjuries;
    }

    public AccidentParticipantsEntity setHasInjuries(boolean hasInjuries) {
        this.HasInjuries = hasInjuries;
        return this;
    }

    @Basic
    @Column(name = "SignUrl", nullable = true, length = 2147483647)
    public String getSignUrl() {
        return SignUrl;
    }

    public AccidentParticipantsEntity setSignUrl(String signUrl) {
        this.SignUrl = signUrl;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return AccidentId;
    }

    public AccidentParticipantsEntity setAccidentId(long accidentId) {
        this.AccidentId = accidentId;
        return this;
    }

    @Basic
    @Column(name = "AccidentCar_Id", nullable = true)
    public Long getAccidentCarId() {
        return AccidentCarId;
    }

    public AccidentParticipantsEntity setAccidentCarId(Long accidentCarId) {
        this.AccidentCarId = accidentCarId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentParticipantsEntity that = (AccidentParticipantsEntity) o;

        if (Id != that.Id) return false;
        if (IsDriver != that.IsDriver) return false;
        if (HasInjuries != that.HasInjuries) return false;
        if (AccidentId != that.AccidentId) return false;
        if (IdCard != null ? !IdCard.equals(that.IdCard) : that.IdCard != null) return false;
        if (SignUrl != null ? !SignUrl.equals(that.SignUrl) : that.SignUrl != null) return false;
        if (AccidentCarId != null ? !AccidentCarId.equals(that.AccidentCarId) : that.AccidentCarId != null)
            return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (IdCard != null ? IdCard.hashCode() : 0);
        result = 31 * result + (IsDriver ? 1 : 0);
        result = 31 * result + (HasInjuries ? 1 : 0);
        result = 31 * result + (SignUrl != null ? SignUrl.hashCode() : 0);
        result = 31 * result + (int) (AccidentId ^ (AccidentId >>> 32));
        result = 31 * result + (AccidentCarId != null ? AccidentCarId.hashCode() : 0);
        return result;
    }
}
