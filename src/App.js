import { BrowserRouter as Router, Route, Link, Switch } from 'react-router-dom'
import React from 'react'
import NoteList from './components/NoteList'
import Test from './components/Test'
import CreateNote from './components/CreateNote'

export default class App extends React.Component {
	render() {
		return (
			<div>	
				
				<Router>
					<Switch>
						<Route path="/" exact component={Home} />
						<Route path="/notes" component={NoteList} />
						<Route path="/test" component={Test} />
						<Route path="/create-note" component={CreateNote} />
						</Switch>
				</Router>			
				
				
			</div>
		)
	}
}
