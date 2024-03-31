import { useEffect} from 'react'
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import LoadingCompanent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';

function App() {
  const {activityStore} = useStore();

 
  useEffect(() => {
   activityStore.loadActivities();
  }, [activityStore]) // передача зависимости

  

  if (activityStore.loadingInitial) return <LoadingCompanent content='Loading app'/>

  return (
    <>
      <NavBar  />
      <Container style={{marginTop: '7em'}} >
        <ActivityDashboard />
      </Container>
    </>
  )
}



export default observer(App); 