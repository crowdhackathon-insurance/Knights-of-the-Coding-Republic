package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentCars", schema = "dbo", catalog = "IlidaDB")
public class AccidentCarsEntity {
    private long Id;
    private String CarPlate;
    private String DamageText;
    private String Remarks;
    private long AccidentId;
    private List<AccidentConditionsEntity> AccidentConditions;
    private List<AccidentsEntity> Accidents;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentCarsEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "CarPlate", nullable = false, length = 10)
    public String getCarPlate() {
        return CarPlate;
    }

    public AccidentCarsEntity setCarPlate(String carPlate) {
        this.CarPlate = carPlate;
        return this;
    }

    @Basic
    @Column(name = "DamageText", nullable = true, length = 2147483647)
    public String getDamageText() {
        return DamageText;
    }

    public AccidentCarsEntity setDamageText(String damageText) {
        this.DamageText = damageText;
        return this;
    }

    @Basic
    @Column(name = "Remarks", nullable = true, length = 2147483647)
    public String getRemarks() {
        return Remarks;
    }

    public AccidentCarsEntity setRemarks(String remarks) {
        this.Remarks = remarks;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return AccidentId;
    }

    public AccidentCarsEntity setAccidentId(long accidentId) {
        this.AccidentId = accidentId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentCarsEntity that = (AccidentCarsEntity) o;

        if (Id != that.Id) return false;
        if (AccidentId != that.AccidentId) return false;
        if (CarPlate != null ? !CarPlate.equals(that.CarPlate) : that.CarPlate != null) return false;
        if (DamageText != null ? !DamageText.equals(that.DamageText) : that.DamageText != null) return false;
        if (Remarks != null ? !Remarks.equals(that.Remarks) : that.Remarks != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (CarPlate != null ? CarPlate.hashCode() : 0);
        result = 31 * result + (DamageText != null ? DamageText.hashCode() : 0);
        result = 31 * result + (Remarks != null ? Remarks.hashCode() : 0);
        result = 31 * result + (int) (AccidentId ^ (AccidentId >>> 32));
        return result;
    }

    @ManyToMany
    @JoinTable(name = "CarAccidentConditions", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "AccidentCarId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "AccidentConditionId", referencedColumnName = "Id", nullable = false))
    public List<AccidentConditionsEntity> getAccidentConditions() {
        return AccidentConditions;
    }

    public AccidentCarsEntity setAccidentConditions(List<AccidentConditionsEntity> accidentConditions) {
        this.AccidentConditions = accidentConditions;
        return this;
    }

    @ManyToMany(mappedBy = "accidentCars")
    public List<AccidentsEntity> getAccidents() {
        return Accidents;
    }

    public AccidentCarsEntity setAccidents(List<AccidentsEntity> accidents) {
        this.Accidents = accidents;
        return this;
    }
}
