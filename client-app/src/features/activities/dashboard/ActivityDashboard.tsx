import { Grid } from "semantic-ui-react";
import ActivityList from "./AcitivityList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import LoadingCompanent from "../../../app/layout/LoadingComponent";



export default observer(function ActivityDashboard() {

    const {activityStore} = useStore();
 
    useEffect(() => {
     activityStore.loadActivities();
    }, [activityStore]) // передача зависимости
  
    if (activityStore.loadingInitial) return <LoadingCompanent content='Loading app'/>
  

    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList />
            </Grid.Column>
            <Grid.Column width='6'>
               <h2>Activity Filters must be heare</h2>
            </Grid.Column>
        </Grid>
    )
})