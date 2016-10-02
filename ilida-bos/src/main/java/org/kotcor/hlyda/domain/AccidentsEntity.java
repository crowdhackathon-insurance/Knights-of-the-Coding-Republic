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
    private long Id;
    private Timestamp OccuredOn;
    private boolean HasInjuries;
    private boolean HasOtherVehicleDamages;
    private boolean HasOtherItemsDamages;
    private double Latitude;
    private double Longitude;
    private long UserId;
    private String DiagramUrl;
    private long WorkflowStatusId;
    private WorkflowStatusEntity WorkflowStatus;
    private List<CompaniesEntity> AccidentCompanies;
    private List<AccidentCarsEntity> AccidentCars;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentsEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "OccuredOn", nullable = false)
    public Timestamp getOccuredOn() {
        return OccuredOn;
    }

    public AccidentsEntity setOccuredOn(Timestamp occuredOn) {
        this.OccuredOn = occuredOn;
        return this;
    }

    @Basic
    @Column(name = "HasInjuries", nullable = false)
    public boolean isHasInjuries() {
        return HasInjuries;
    }

    public AccidentsEntity setHasInjuries(boolean hasInjuries) {
        this.HasInjuries = hasInjuries;
        return this;
    }

    @Basic
    @Column(name = "HasOtherVehicleDamages", nullable = false)
    public boolean isHasOtherVehicleDamages() {
        return HasOtherVehicleDamages;
    }

    public AccidentsEntity setHasOtherVehicleDamages(boolean hasOtherVehicleDamages) {
        this.HasOtherVehicleDamages = hasOtherVehicleDamages;
        return this;
    }

    @Basic
    @Column(name = "HasOtherItemsDamages", nullable = false)
    public boolean isHasOtherItemsDamages() {
        return HasOtherItemsDamages;
    }

    public AccidentsEntity setHasOtherItemsDamages(boolean hasOtherItemsDamages) {
        this.HasOtherItemsDamages = hasOtherItemsDamages;
        return this;
    }

    @Basic
    @Column(name = "Latitude", nullable = false, precision = 0)
    public double getLatitude() {
        return Latitude;
    }

    public AccidentsEntity setLatitude(double latitude) {
        this.Latitude = latitude;
        return this;
    }

    @Basic
    @Column(name = "Longitude", nullable = false, precision = 0)
    public double getLongitude() {
        return Longitude;
    }

    public AccidentsEntity setLongitude(double longitude) {
        this.Longitude = longitude;
        return this;
    }

    @Basic
    @Column(name = "UserId", nullable = false)
    public long getUserId() {
        return UserId;
    }

    public AccidentsEntity setUserId(long userId) {
        this.UserId = userId;
        return this;
    }

    @Basic
    @Column(name = "DiagramUrl", nullable = true, length = 2147483647)
    public String getDiagramUrl() {
        return DiagramUrl;
    }

    public AccidentsEntity setDiagramUrl(String diagramUrl) {
        this.DiagramUrl = diagramUrl;
        return this;
    }

    @Basic
    @Column(name = "WorkflowStatusId", nullable = false)
    public long getWorkflowStatusId() {
        return WorkflowStatusId;
    }

    public AccidentsEntity setWorkflowStatusId(long workflowStatusId) {
        this.WorkflowStatusId = workflowStatusId;
        return this;
    }

    @Transient
    public WorkflowStatusEntity getWorkflowStatus() {
        return WorkflowStatus;
    }

    public AccidentsEntity setWorkflowStatus(WorkflowStatusEntity workflowStatus) {
        WorkflowStatus = workflowStatus;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentsEntity that = (AccidentsEntity) o;

        if (Id != that.Id) return false;
        if (HasInjuries != that.HasInjuries) return false;
        if (HasOtherVehicleDamages != that.HasOtherVehicleDamages) return false;
        if (HasOtherItemsDamages != that.HasOtherItemsDamages) return false;
        if (Double.compare(that.Latitude, Latitude) != 0) return false;
        if (Double.compare(that.Longitude, Longitude) != 0) return false;
        if (UserId != that.UserId) return false;
        if (WorkflowStatusId != that.WorkflowStatusId) return false;
        if (OccuredOn != null ? !OccuredOn.equals(that.OccuredOn) : that.OccuredOn != null) return false;
        if (DiagramUrl != null ? !DiagramUrl.equals(that.DiagramUrl) : that.DiagramUrl != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result;
        long temp;
        result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (OccuredOn != null ? OccuredOn.hashCode() : 0);
        result = 31 * result + (HasInjuries ? 1 : 0);
        result = 31 * result + (HasOtherVehicleDamages ? 1 : 0);
        result = 31 * result + (HasOtherItemsDamages ? 1 : 0);
        temp = Double.doubleToLongBits(Latitude);
        result = 31 * result + (int) (temp ^ (temp >>> 32));
        temp = Double.doubleToLongBits(Longitude);
        result = 31 * result + (int) (temp ^ (temp >>> 32));
        result = 31 * result + (int) (UserId ^ (UserId >>> 32));
        result = 31 * result + (DiagramUrl != null ? DiagramUrl.hashCode() : 0);
        result = 31 * result + (int) (WorkflowStatusId ^ (WorkflowStatusId >>> 32));
        return result;
    }

    @ManyToMany
    @JoinTable(name = "AccidentCompanies", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "AccidentId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "CompanyId", referencedColumnName = "Id", nullable = false))
    public List<CompaniesEntity> getAccidentCompanies() {
        return AccidentCompanies;
    }

    public AccidentsEntity setAccidentCompanies(List<CompaniesEntity> accidentCompanies) {
        this.AccidentCompanies = accidentCompanies;
        return this;
    }

    @ManyToMany
    @JoinTable(name = "CarAccidentConditions", catalog = "IlidaDB", schema = "dbo", joinColumns = @JoinColumn(name = "AccidentId", referencedColumnName = "Id", nullable = false), inverseJoinColumns = @JoinColumn(name = "AccidentCarId", referencedColumnName = "Id", nullable = false))
    public List<AccidentCarsEntity> getAccidentCars() {
        return AccidentCars;
    }

    public AccidentsEntity setAccidentCars(List<AccidentCarsEntity> accidentCars) {
        this.AccidentCars = accidentCars;
        return this;
    }
}
