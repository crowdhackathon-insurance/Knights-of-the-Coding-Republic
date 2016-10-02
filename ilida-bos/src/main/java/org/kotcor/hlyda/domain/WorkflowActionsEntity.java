package org.kotcor.hlyda.domain;

import javax.persistence.*;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "WorkflowActions", schema = "dbo", catalog = "IlidaDB")
public class WorkflowActionsEntity {
    private long id;
    private String description;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public WorkflowActionsEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Description", nullable = false, length = 255)
    public String getDescription() {
        return description;
    }

    public WorkflowActionsEntity setDescription(String description) {
        this.description = description;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        WorkflowActionsEntity that = (WorkflowActionsEntity) o;

        if (id != that.id) return false;
        if (description != null ? !description.equals(that.description) : that.description != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (description != null ? description.hashCode() : 0);
        return result;
    }
}
