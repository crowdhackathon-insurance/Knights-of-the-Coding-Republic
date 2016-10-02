package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentParticipants", schema = "dbo", catalog = "IlidaDB")
public class AccidentParticipantsEntity {
    private long id;
    private String idCard;
    private boolean isDriver;
    private boolean hasInjuries;
    private String signUrl;
    private long accidentId;
    private Long accidentCarId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentParticipantsEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "IdCard", nullable = false, length = 10)
    public String getIdCard() {
        return idCard;
    }

    public AccidentParticipantsEntity setIdCard(String idCard) {
        this.idCard = idCard;
        return this;
    }

    @Basic
    @Column(name = "IsDriver", nullable = false)
    public boolean isDriver() {
        return isDriver;
    }

    public AccidentParticipantsEntity setDriver(boolean driver) {
        isDriver = driver;
        return this;
    }

    @Basic
    @Column(name = "HasInjuries", nullable = false)
    public boolean isHasInjuries() {
        return hasInjuries;
    }

    public AccidentParticipantsEntity setHasInjuries(boolean hasInjuries) {
        this.hasInjuries = hasInjuries;
        return this;
    }

    @Basic
    @Column(name = "SignUrl", nullable = true, length = 2147483647)
    public String getSignUrl() {
        return signUrl;
    }

    public AccidentParticipantsEntity setSignUrl(String signUrl) {
        this.signUrl = signUrl;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return accidentId;
    }

    public AccidentParticipantsEntity setAccidentId(long accidentId) {
        this.accidentId = accidentId;
        return this;
    }

    @Basic
    @Column(name = "AccidentCar_Id", nullable = true)
    public Long getAccidentCarId() {
        return accidentCarId;
    }

    public AccidentParticipantsEntity setAccidentCarId(Long accidentCarId) {
        this.accidentCarId = accidentCarId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentParticipantsEntity that = (AccidentParticipantsEntity) o;

        if (id != that.id) return false;
        if (isDriver != that.isDriver) return false;
        if (hasInjuries != that.hasInjuries) return false;
        if (accidentId != that.accidentId) return false;
        if (idCard != null ? !idCard.equals(that.idCard) : that.idCard != null) return false;
        if (signUrl != null ? !signUrl.equals(that.signUrl) : that.signUrl != null) return false;
        if (accidentCarId != null ? !accidentCarId.equals(that.accidentCarId) : that.accidentCarId != null)
            return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (idCard != null ? idCard.hashCode() : 0);
        result = 31 * result + (isDriver ? 1 : 0);
        result = 31 * result + (hasInjuries ? 1 : 0);
        result = 31 * result + (signUrl != null ? signUrl.hashCode() : 0);
        result = 31 * result + (int) (accidentId ^ (accidentId >>> 32));
        result = 31 * result + (accidentCarId != null ? accidentCarId.hashCode() : 0);
        return result;
    }
}
