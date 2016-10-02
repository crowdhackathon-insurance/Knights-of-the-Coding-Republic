package org.kotcor.hlyda.domain;

import javax.persistence.*;
import java.sql.Timestamp;

/**
 * Created by KPentaris on 01-Oct-16.
 */
@Entity
@Table(name = "AccidentActions", schema = "dbo", catalog = "IlidaDB")
public class AccidentActionsEntity {
    private long Id;
    private Timestamp Timestamp;
    private long PreviousWorkflowStatusId;
    private long NextWorkflowStatusId;
    private String Comment;
    private long AccidentId;
    private long UserId;
    private long WorkflowActionId;

    @Id
    @Column(name = "Id", nullable = false)
    public long getId() {
        return Id;
    }

    public AccidentActionsEntity setId(long id) {
        this.Id = id;
        return this;
    }

    @Basic
    @Column(name = "Timestamp", nullable = false)
    public Timestamp getTimestamp() {
        return Timestamp;
    }

    public AccidentActionsEntity setTimestamp(Timestamp timestamp) {
        this.Timestamp = timestamp;
        return this;
    }

    @Basic
    @Column(name = "PreviousWorkflowStatusId", nullable = false)
    public long getPreviousWorkflowStatusId() {
        return PreviousWorkflowStatusId;
    }

    public AccidentActionsEntity setPreviousWorkflowStatusId(long previousWorkflowStatusId) {
        this.PreviousWorkflowStatusId = previousWorkflowStatusId;
        return this;
    }

    @Basic
    @Column(name = "NextWorkflowStatusId", nullable = false)
    public long getNextWorkflowStatusId() {
        return NextWorkflowStatusId;
    }

    public AccidentActionsEntity setNextWorkflowStatusId(long nextWorkflowStatusId) {
        this.NextWorkflowStatusId = nextWorkflowStatusId;
        return this;
    }

    @Basic
    @Column(name = "Comment", nullable = true, length = 2147483647)
    public String getComment() {
        return Comment;
    }

    public AccidentActionsEntity setComment(String comment) {
        this.Comment = comment;
        return this;
    }

    @Basic
    @Column(name = "AccidentId", nullable = false)
    public long getAccidentId() {
        return AccidentId;
    }

    public AccidentActionsEntity setAccidentId(long accidentId) {
        this.AccidentId = accidentId;
        return this;
    }

    @Basic
    @Column(name = "UserId", nullable = false)
    public long getUserId() {
        return UserId;
    }

    public AccidentActionsEntity setUserId(long userId) {
        this.UserId = userId;
        return this;
    }

    @Basic
    @Column(name = "WorkflowActionId", nullable = false)
    public long getWorkflowActionId() {
        return WorkflowActionId;
    }

    public AccidentActionsEntity setWorkflowActionId(long workflowActionId) {
        this.WorkflowActionId = workflowActionId;
        return this;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AccidentActionsEntity that = (AccidentActionsEntity) o;

        if (Id != that.Id) return false;
        if (PreviousWorkflowStatusId != that.PreviousWorkflowStatusId) return false;
        if (NextWorkflowStatusId != that.NextWorkflowStatusId) return false;
        if (AccidentId != that.AccidentId) return false;
        if (UserId != that.UserId) return false;
        if (WorkflowActionId != that.WorkflowActionId) return false;
        if (Timestamp != null ? !Timestamp.equals(that.Timestamp) : that.Timestamp != null) return false;
        if (Comment != null ? !Comment.equals(that.Comment) : that.Comment != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (Id ^ (Id >>> 32));
        result = 31 * result + (Timestamp != null ? Timestamp.hashCode() : 0);
        result = 31 * result + (int) (PreviousWorkflowStatusId ^ (PreviousWorkflowStatusId >>> 32));
        result = 31 * result + (int) (NextWorkflowStatusId ^ (NextWorkflowStatusId >>> 32));
        result = 31 * result + (Comment != null ? Comment.hashCode() : 0);
        result = 31 * result + (int) (AccidentId ^ (AccidentId >>> 32));
        result = 31 * result + (int) (UserId ^ (UserId >>> 32));
        result = 31 * result + (int) (WorkflowActionId ^ (WorkflowActionId >>> 32));
        return result;
    }
}
