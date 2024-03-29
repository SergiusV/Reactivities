import { Grid } from "semantic-ui-react";
import ActivityList from "./AcitivityList";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/activityForm";
import { Activity } from "../../../app/models/activity";

interface Props {
    activities: Activity[];
    selectedActivity: Activity| undefined;
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
    createOrEditActivity: (activity: Activity) => void;
    deleteActivity: (id: string) => void;
}

export default function ActivityDashboard({activities, 
                                            selectedActivity, 
                                            selectActivity, 
                                            cancelSelectActivity,
                                            editMode,
                                            openForm,
                                            closeForm,
                                            createOrEditActivity,
                                            deleteActivity
                                        }: Props) {

    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList 
                    activities={activities} 
                    selectActivity={selectActivity}
                    deleteActivity={deleteActivity}
                />
            </Grid.Column>
            <Grid.Column width='6'>
                {selectedActivity && !editMode &&
                    <ActivityDetails 
                        activity={selectedActivity} 
                        cancelSelectActivity={cancelSelectActivity}
                        openForm={openForm}

                    />}
                    {editMode &&
                    <ActivityForm closeForm={closeForm} activity={selectedActivity} createOrEditActivity={createOrEditActivity}/>}
            </Grid.Column>
        </Grid>
    )
}