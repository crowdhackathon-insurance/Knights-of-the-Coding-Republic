package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "WorkflowActions", schema = "dbo", catalog = "IlidaDB")
public class WorkflowActionsEntity {
    private long Id;
    private String Description;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public WorkflowActionsEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Description", nullable = false, length = 255)
    public String getDescription() {
        return Description;
    }

    public WorkflowActionsEntity setDescription(String description) {
        this.Description = description;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        WorkflowActionsEntity that = (WorkflowActionsEntity) o;

        if (Id != that.Id) return false;
        if (Description != null ? !Description.equals(that.Description) : that.Description != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (Description != null ? Description.hashCode() : 0);
        return result;
    }
}
