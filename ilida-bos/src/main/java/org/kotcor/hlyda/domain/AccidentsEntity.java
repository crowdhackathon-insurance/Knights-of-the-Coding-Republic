package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.sql.Timestamp;
import java.util.List;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "Accidents", schema = "dbo", catalog = "IlidaDB")
public class AccidentsEntity {
    private long id;
    private Timestamp occuredOn;
    private boolean hasInjuries;
    private boolean hasOtherVehicleDamages;
    private boolean hasOtherItemsDamages;
    private double latitude;
    private double longitude;
    private long userId;
    private String diagramUrl;
    private long workflowStatusId;
    private List<CompaniesEntity> companies;
    private List<AccidentCarsEntity> cars;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentsEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "OccuredOn", nullable = false)
    public Timestamp getOccuredOn() {
        return occuredOn;
    }

    public AccidentsEntity setOccuredOn(Timestamp occuredOn) {
        this.occuredOn = occuredOn;
        return this;
    }

    @Basic
    @Column(name = "HasInjuries", nullable = false)
    public boolean isHasInjuries() {
        return hasInjuries;
    }

    public AccidentsEntity setHasInjuries(boolean hasInjuries) {
        this.hasInjuries = hasInjuries;
        return this;
    }

    @Basic
    @Column(name = "HasOtherVehicleDamages", nullable = false)
    public boolean isHasOtherVehicleDamages() {
        return hasOtherVehicleDamages;
    }

    public AccidentsEntity setHasOtherVehicleDamages(boolean hasOtherVehicleDamages) {
        this.hasOtherVehicleDamages = hasOtherVehicleDamages;
        return this;
    }

    @Basic
    @Column(name = "HasOtherItemsDamages", nullable = false)
    public boolean isHasOtherItemsDamages() {
        return hasOtherItemsDamages;
    }

    public AccidentsEntity setHasOtherItemsDamages(boolean hasOtherItemsDamages) {
        this.hasOtherItemsDamages = hasOtherItemsDamages;
        return this;
    }

    @Basic
    @Column(name = "Latitude", nullable = false, precision = 0)
    public double getLatitude() {
        return latitude;
    }

    public AccidentsEntity setLatitude(double latitude) {
        this.latitude = latitude;
        return this;
    }

    @Basic
    @Column(name = "Longitude", nullable = false, precision = 0)
    public double getLongitude() {
        return longitude;
    }

    public AccidentsEntity setLongitude(double longitude) {
        this.longitude = longitude;
        return this;
    }

    @Basic
    @Column(name = "UserId", nullable = false)
    public long getUserId() {
        return userId;
    }

    public AccidentsEntity setUserId(long userId) {
        this.userId = userId;
        return this;
    }

    @Basic
    @Column(name = "DiagramUrl", nullable = true, length = 2147483647)
    public String getDiagramUrl() {
        return diagramUrl;
    }

    public AccidentsEntity setDiagramUrl(String diagramUrl) {
        this.diagramUrl = diagramUrl;
        return this;
    }

    @Basic
    @Column(name = "WorkflowStatusId", nullable = false)
    public long getWorkflowStatusId() {
        return workflowStatusId;
    }

    public AccidentsEntity setWorkflowStatusId(long workflowStatusId) {
        this.workflowStatusId = workflowStatusId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentsEntity that = (AccidentsEntity) o;

        if (id != that.id) return false;
        if (hasInjuries != that.hasInjuries) return false;
        if (hasOtherVehicleDamages != that.hasOtherVehicleDamages) return false;
        if (hasOtherItemsDamages != that.hasOtherItemsDamages) return false;
        if (Double.compare(that.latitude, latitude) != 0) return false;
        if (Double.compare(that.longitude, longitude) != 0) return false;
        if (userId != that.userId) return false;
        if (workflowStatusId != that.workflowStatusId) return false;
        if (occuredOn != null ? !occuredOn.equals(that.occuredOn) : that.occuredOn != null) return false;
        if (diagramUrl != null ? !diagramUrl.equals(that.diagramUrl) : that.diagramUrl != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result;
        long temp;
        result = (int) (id ^ (id >>> 32));
        result = 31 * result + (occuredOn != null ? occuredOn.hashCode() : 0);
        result = 31 * result + (hasInjuries ? 1 : 0);
        result = 31 * result + (hasOtherVehicleDamages ? 1 : 0);
        result = 31 * result + (hasOtherItemsDamages ? 1 : 0);
        temp = Double.doubleToLongBits(latitude);
        result = 31 * result + (int) (temp ^ (temp >>> 32));
        temp = Double.doubleToLongBits(longitude);
        result = 31 * result + (int) (temp ^ (temp >>> 32));
        result = 31 * result + (int) (userId ^ (userId >>> 32));
        result = 31 * result + (diagramUrl != null ? diagramUrl.hashCode() : 0);
        result = 31 * result + (int) (workflowStatusId ^ (workflowStatusId >>> 32));
        return result;
    }

    @ManyToMany
    @JoinTable(name = "AccidentCompanies", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "AccidentId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "CompanyId", referencedColumnName = "Id", nullable = false))
    public List<CompaniesEntity> getCompanies() {
        return companies;
    }

    public AccidentsEntity setCompanies(List<CompaniesEntity> companies) {
        this.companies = companies;
        return this;
    }

    @ManyToMany
    @JoinTable(name = "CarAccidentConditions", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "AccidentId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "AccidentCarId", referencedColumnName = "Id", nullable = false))
    public List<AccidentCarsEntity> getCars() {
        return cars;
    }

    public AccidentsEntity setCars(List<AccidentCarsEntity> cars) {
        this.cars = cars;
        return this;
    }
}
