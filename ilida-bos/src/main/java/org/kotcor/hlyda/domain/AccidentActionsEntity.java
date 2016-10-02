package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.sql.Timestamp;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentActions", schema = "dbo", catalog = "IlidaDB")
public class AccidentActionsEntity {
    private long id;
    private Timestamp timestamp;
    private long previousWorkflowStatusId;
    private long nextWorkflowStatusId;
    private String comment;
    private long accidentId;
    private long userId;
    private long workflowActionId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return id;
    }

    public AccidentActionsEntity setId(long id) {
        this.id = id;
        return this;
    }

    @Basic
    @Column(name = "Timestamp", nullable = false)
    public Timestamp getTimestamp() {
        return timestamp;
    }

    public AccidentActionsEntity setTimestamp(Timestamp timestamp) {
        this.timestamp = timestamp;
        return this;
    }

    @Basic
    @Column(name = "PreviousWorkflowStatusId", nullable = false)
    public long getPreviousWorkflowStatusId() {
        return previousWorkflowStatusId;
    }

    public AccidentActionsEntity setPreviousWorkflowStatusId(long previousWorkflowStatusId) {
        this.previousWorkflowStatusId = previousWorkflowStatusId;
        return this;
    }

    @Basic
    @Column(name = "NextWorkflowStatusId", nullable = false)
    public long getNextWorkflowStatusId() {
        return nextWorkflowStatusId;
    }

    public AccidentActionsEntity setNextWorkflowStatusId(long nextWorkflowStatusId) {
        this.nextWorkflowStatusId = nextWorkflowStatusId;
        return this;
    }

    @Basic
    @Column(name = "Comment", nullable = true, length = 2147483647)
    public String getComment() {
        return comment;
    }

    public AccidentActionsEntity setComment(String comment) {
        this.comment = comment;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return accidentId;
    }

    public AccidentActionsEntity setAccidentId(long accidentId) {
        this.accidentId = accidentId;
        return this;
    }

    @Basic
    @Column(name = "UserId", nullable = false)
    public long getUserId() {
        return userId;
    }

    public AccidentActionsEntity setUserId(long userId) {
        this.userId = userId;
        return this;
    }

    @Basic
    @Column(name = "WorkflowActionId", nullable = false)
    public long getWorkflowActionId() {
        return workflowActionId;
    }

    public AccidentActionsEntity setWorkflowActionId(long workflowActionId) {
        this.workflowActionId = workflowActionId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentActionsEntity that = (AccidentActionsEntity) o;

        if (id != that.id) return false;
        if (previousWorkflowStatusId != that.previousWorkflowStatusId) return false;
        if (nextWorkflowStatusId != that.nextWorkflowStatusId) return false;
        if (accidentId != that.accidentId) return false;
        if (userId != that.userId) return false;
        if (workflowActionId != that.workflowActionId) return false;
        if (timestamp != null ? !timestamp.equals(that.timestamp) : that.timestamp != null) return false;
        if (comment != null ? !comment.equals(that.comment) : that.comment != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (id ^ (id >>> 32));
        result = 31 * result + (timestamp != null ? timestamp.hashCode() : 0);
        result = 31 * result + (int) (previousWorkflowStatusId ^ (previousWorkflowStatusId >>> 32));
        result = 31 * result + (int) (nextWorkflowStatusId ^ (nextWorkflowStatusId >>> 32));
        result = 31 * result + (comment != null ? comment.hashCode() : 0);
        result = 31 * result + (int) (accidentId ^ (accidentId >>> 32));
        result = 31 * result + (int) (userId ^ (userId >>> 32));
        result = 31 * result + (int) (workflowActionId ^ (workflowActionId >>> 32));
        return result;
    }
}
