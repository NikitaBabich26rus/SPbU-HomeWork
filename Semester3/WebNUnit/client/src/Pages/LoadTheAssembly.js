import React, {Fragment, useEffect, useState} from "react"
import {Button, Grid, Input, List, ListItem, ListItemText, Paper, TextField, useScrollTrigger} from "@material-ui/core"
import Typography from '@material-ui/core/Typography';
import {Moment} from 'moment'

export const LoadTheAssembly = () => {
    const [file, setFile] = useState()
    const [loadedFiles, setLoadedFiles] = useState(null)

    const saveFile = (e) => {
        setFile(e.target.files[0])
    }

    const upload = async () => {
        let postSettings = {
            method: 'POST',
        };
        let data = new FormData();
        data.append('file', file)
        postSettings.body = data;
        const response = await fetch('http://localhost:5000/api/Home/loadTheAssembly', postSettings)
        await getLoadedFiles()
    }

    const getLoadedFiles = async () => {
        const response = await fetch('http://localhost:5000/api/Home/getLoadAssembly')
        const data = await response.json()
        setLoadedFiles(data)
    }

    const deleteAllLoadedFiles = async () => {
        setLoadedFiles(null)
        await fetch('http://localhost:5000/api/Home/deleteLoadedAssemblies', {
            method: 'DELETE',
        })
        await getLoadedFiles()
    }

    useEffect(() =>{
      getLoadedFiles()
    }, [])

    return(
        <Fragment>
            <Grid container justify='center' style={{ marginTop: '15px'}}>
                <Grid item xs='11'>
                    <Input type='file' inputProps={{ accept: '.dll' }} onChange={saveFile}/>
                    <Input type='button' value='Загрузить' onClick={upload}/>
                </Grid>
                <Grid item xs='11'>
                    <Button
                        style={{ marginTop: '25px'}}
                        size="small"
                        variant="contained"
                        color="primary"
                        onClick={deleteAllLoadedFiles}
                    >
                        Удалить загруженные сборки
                    </Button>
                    <Typography variant="h6" style={{ marginTop: '15px'}}>
                        Загруженные сборки:
                    </Typography>
                    <List>
                        {loadedFiles !== null && loadedFiles.map((file) => {
                            return (
                                <ListItem>
                                    <ListItemText>
                                        {file.name}
                                    </ListItemText>
                            </ListItem>)
                        })}
                    </List>
                </Grid>
            </Grid>
        </Fragment>
    )
}


