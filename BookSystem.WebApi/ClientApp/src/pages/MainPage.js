import React from 'react'

import { connect } from 'react-redux'
import { Redirect } from 'react-router';
import { Route, Link } from 'react-router-dom';

import { Menu, Segment, Container, Dropdown } from 'semantic-ui-react'

import {doLogOut} from '../actions'

import StorePage from './StorePage'
import FundPage from './FundPage'

class MainPage extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      activePage: 'Store'
    }
  }


  viewContainer = () => {
    return (
      <Container>
        <Route exact path='/' component={StorePage} />
        <Route exact path='/store' component={StorePage} />
        <Route exact path='/fund' component={FundPage} />
      </Container>
    )
  }

  handleItemClick = (e, { name }) => {
    this.setState({ activePage: name })
  }

  render() {
    if (this.props.loggedInUser !== null) {
      return (
        <div>
          <Segment inverted >
            <Menu inverted pointing secondary stackable>
              <Container>
                <Menu.Item
                  as={Link}
                  to='/store'
                  name='Store'
                  active={this.state.activePage === 'Store'}
                  onClick={this.handleItemClick} />
                <Menu.Item
                  as={Link}
                  to='/fund'
                  name='Fund'
                  active={this.state.activePage === 'Fund'}
                  onClick={this.handleItemClick}
                />
                <Menu.Menu position='right'>
                  <Menu.Item>
                    <Dropdown floating text={this.props.loggedInUser.lastname}>
                      <Dropdown.Menu>
                        <Dropdown.Header icon='user' content={'Signed In as '+ this.props.loggedInUser.username} />
                        <Dropdown.Item icon='edit' text='Manage Funded Book' />
                        <Dropdown.Item icon='globe' text='Book Requested' />
                        <Dropdown.Item icon='globe' text='Aprove Section' />
                        <Dropdown.Divider />
                        <Dropdown.Item icon='log out' text='Log Out' onClick={this.props.doLogOut}/>
                      </Dropdown.Menu>
                    </Dropdown>
                  </Menu.Item>
                  
                </Menu.Menu>
              </Container>
            </Menu>
          </Segment>
          {this.viewContainer()}
        </div>
      )
    } else {
      return (
        <Redirect push to="/auth" />
      )
    }
  }
}

const mapStateToProps = (state) => {
  return {
    loggedInUser: state.loggedInUser
  };
}

export default connect(mapStateToProps, {doLogOut})(MainPage)