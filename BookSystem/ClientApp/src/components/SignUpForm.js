import React from 'react'

import { Button, Form, Segment } from 'semantic-ui-react'
import {connect} from 'react-redux'
import {doUserRegister} from '../actions'

class SignUpForm extends React.Component {
  constructor(props){
    super(props)
    this.state = {
      username: '',
      password: '',
      firstname: '',
      lastname: '',
      email: '',
      repassword: ''
    }
  }

  onFormSubmit = (e) => {
    e.preventDefault();
    this.props.doUserRegister(this.state)
  }

  render() {
    return (
      <Form size='large' onSubmit={this.onFormSubmit}>
        <Segment stacked>
          <Form.Input
            fluid
            icon='user'
            iconPosition='left'
            placeholder='Username'
            onChange = {(event, data) => this.setState({username: data.value})}
          />
          <Form.Input
            fluid
            icon='user'
            iconPosition='left'
            placeholder='First Name'
            onChange = {(event, data) => this.setState({firstname: data.value})}
          />
          <Form.Input
            fluid
            icon='user'
            iconPosition='left'
            placeholder='Last Name'
            onChange = {(event, data) => this.setState({lastname: data.value})}
          />
          <Form.Input
            fluid
            icon='mail'
            iconPosition='left'
            placeholder='Email'
            onChange = {(event, data) => this.setState({email: data.value})}
          />

          <Form.Input
            fluid
            icon='lock'
            iconPosition='left'
            placeholder='Password'
            type='password'
            onChange = {(event, data) => this.setState({password: data.value})}
          />

          <Form.Input
            fluid
            icon='lock'
            iconPosition='left'
            placeholder='Re-enter Password'
            type='password'
            onChange = {(event, data) => this.setState({repassword: data.value})}
          />

          <Button color='orange' fluid size='large'>
            Sign Up
          </Button>
        </Segment>
      </Form>
    )
  }
}

const mapStateToProps = (state) => {
  // console.log("BotNavigation: ",state);
  return {
      // respone: state.respone
  };
}

export default connect(mapStateToProps, {doUserRegister})(SignUpForm)