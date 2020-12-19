import React from 'react';
import { makeStyles } from '@material-ui/styles';
import { Grid, Typography } from '@material-ui/core';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4)
  },
  content: {
    paddingTop: 50,
    textAlign: 'center'
  },
  image: {
    marginTop: 30,
    display: 'inline-block',
    maxWidth: '100%',
    width: 560
  }
}));

const NotFound = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Grid
        container
        justify="center"
        spacing={4}
      >
        <Grid
          item
          lg={6}
          xs={12}
        >
          <div className={classes.content}>
            <Typography variant="h1">
              404: Página não encontrada!
            </Typography>
            <Typography variant="subtitle1">
              A página que você tentou acessar não foi encontrada. <br></br>
              Verifique o endereço digitado ou entre em contato com nosso suporte: <a href="mailto: regislima1391@gmail.com">regislima1391@gmail.com</a>
            </Typography>
            <img
              alt="Página não encontrada"
              className={classes.image}
              src="/images/not_found.png"
            />
          </div>
        </Grid>
      </Grid>
    </div>
  );
};

export default NotFound;
