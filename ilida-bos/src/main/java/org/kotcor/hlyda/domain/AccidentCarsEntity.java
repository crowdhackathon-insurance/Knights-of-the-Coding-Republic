package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentCars", schema = "dbo", catalog = "IlidaDB")
public class AccidentCarsEntity {
    private long id;
    private String carPlate;
    private String damageText;
    private String remarks;
    private long accidentId;
    private List<AccidentConditionsEntity> conditions;
    private List<AccidentsEntity> accidents;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentCarsEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "CarPlate", nullable = false, length = 10)
    public String getCarPlate() {
        return carPlate;
    }

    public AccidentCarsEntity setCarPlate(String carPlate) {
        this.carPlate = carPlate;
        return this;
    }

    @Basic
    @Column(name = "DamageText", nullable = true, length = 2147483647)
    public String getDamageText() {
        return damageText;
    }

    public AccidentCarsEntity setDamageText(String damageText) {
        this.damageText = damageText;
        return this;
    }

    @Basic
    @Column(name = "Remarks", nullable = true, length = 2147483647)
    public String getRemarks() {
        return remarks;
    }

    public AccidentCarsEntity setRemarks(String remarks) {
        this.remarks = remarks;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return accidentId;
    }

    public AccidentCarsEntity setAccidentId(long accidentId) {
        this.accidentId = accidentId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentCarsEntity that = (AccidentCarsEntity) o;

        if (id != that.id) return false;
        if (accidentId != that.accidentId) return false;
        if (carPlate != null ? !carPlate.equals(that.carPlate) : that.carPlate != null) return false;
        if (damageText != null ? !damageText.equals(that.damageText) : that.damageText != null) return false;
        if (remarks != null ? !remarks.equals(that.remarks) : that.remarks != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (carPlate != null ? carPlate.hashCode() : 0);
        result = 31 * result + (damageText != null ? damageText.hashCode() : 0);
        result = 31 * result + (remarks != null ? remarks.hashCode() : 0);
        result = 31 * result + (int) (accidentId ^ (accidentId >>> 32));
        return result;
    }

    @ManyToMany
    @JoinTable(name = "CarAccidentConditions", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "AccidentCarId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "AccidentConditionId", referencedColumnName = "Id", nullable = false))
    public List<AccidentConditionsEntity> getConditions() {
        return conditions;
    }

    public AccidentCarsEntity setConditions(List<AccidentConditionsEntity> conditions) {
        this.conditions = conditions;
        return this;
    }

    @ManyToMany(mappedBy = "cars")
    public List<AccidentsEntity> getAccidents() {
        return accidents;
    }

    public AccidentCarsEntity setAccidents(List<AccidentsEntity> accidents) {
        this.accidents = accidents;
        return this;
    }
}
