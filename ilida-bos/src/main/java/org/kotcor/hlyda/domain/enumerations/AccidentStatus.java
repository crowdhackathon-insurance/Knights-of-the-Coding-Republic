package org.kotcor.hlyda.domain.enumerations;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by KPentaris on 01-Oct-16.
 */
public enum AccidentStatus {

    submitted(1),
    inProcess(2),
    assignToExpert(3),
    expertOnTheMove(4),
    registeringAccidentDetails(5),
    toBePublished(6),
    settlement(7),
    payout(8),
    completed(9),
    denied(10);

    private int value;
    private static Map<Integer, AccidentStatus> lookup = new HashMap<>();

    AccidentStatus(int value) {
        this.value = value;
    }

    public int getValue() {
        return this.value;
    }

    public static AccidentStatus get(int value) {
        return lookup.get(value);
    }

    public static Collection<AccidentStatus> get() {
        return lookup.values();
    }

    public static Collection<Integer> getKeys() {
        return lookup.keySet();
    }

    static {
        for (AccidentStatus value : AccidentStatus.values()) {
            lookup.put(value.getValue(), value);
        }
    }
}
